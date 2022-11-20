import 'dart:convert';
import 'dart:developer';

import 'package:audioplayers/audioplayers.dart';
import 'package:bartender_app/api/signalr.dart';
import 'package:bartender_app/models/item/item_model.dart';
import 'package:bartender_app/models/order/detail_dct_model.dart';
import 'package:bartender_app/models/order/order_detail_model.dart';
import 'package:bartender_app/models/order/order_model.dart';
import 'package:bartender_app/repositories/item_repo.dart';
import 'package:bartender_app/repositories/order_repo.dart';
import 'package:bartender_app/utils/const.dart';
import 'package:bartender_app/utils/local_storage.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

part 'home_event.dart';
part 'home_state.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  final ItemRepo _itemRepo = ItemRepo();
  final OrderRepo _orderRepo = OrderRepo();
  final SignalR _signalr = SignalR();
  HomeBloc() : super(HomeInitialState()) {
    on<HomeLoadDataEvent>(_onLoadData);
    on<HomeOrderChangeEvent>(_onOrderChange);
    on<HomeOrderDoneChangeEvent>(_onOrderDoneChange);
    on<HomeOrderPinEvent>(_onOrderPin);
    on<HomeItemCheckboxChangeEvent>(_onItemCheckboxChange);
    on<HomeOrderTabChangeEvent>(_onOrderTabChange);
    on<HomeOrderSubmitEvent>(_onOrderSubmit);
    on<HomeListenRecieveNewOrderEvent>(_onListenRecieveNewOrder);
    on<HomeRecieveNewOrderEvent>(_onRecieveNewOrder);
  }

  void _onLoadData(HomeLoadDataEvent event, Emitter<HomeState> emit) async {
    emit(HomeUpdateLoadingState(true, "Đang tải Menu..."));

    try {
      // Load List Item --------------------------------------------------
      var lstItem = <ItemModel>[];
      var lstItemJson = await LocalStorage.getItem(KeyLS.items);
      if (lstItemJson != null) {
        var lstItemDecode = jsonDecode(lstItemJson);
        lstItem = List<ItemModel>.from(
          lstItemDecode.map((model) => ItemModel.fromJson(model)),
        );
      } else {
        lstItem = await _itemRepo.getAll();
      }
      // Load List Order --------------------------------------------------
      if (lstItem.isNotEmpty) {
        emit(HomeItemsLoadedState(true, 'Tải Menu thành công'));
        emit(HomeUpdateLoadingState(true, "Đang tải Order..."));
        var barOrder = await _orderRepo.getBartenderOrders();

        String selOrder = '';
        var lstOrder = <OrderModel>[];
        var lstDetail = <OrderDetailModel>[];
        if (barOrder!.listOrderNew.isNotEmpty) {
          lstOrder = _assignItemToOrder(barOrder.listOrderNew, lstItem);
          selOrder = lstOrder[0].id!;
          lstDetail = lstOrder[0].orderDetails!;
        }

        String selOrderDone = '';
        var lstOrderDone = <OrderModel>[];
        if (barOrder.listOrderCompleted.isNotEmpty) {
          lstOrderDone =
              _assignItemToOrder(barOrder.listOrderCompleted, lstItem);
          selOrderDone = lstOrderDone[0].id!;
        }

        emit(HomeOrdersLoadedState(
          selOrder,
          lstOrder,
          selOrderDone,
          lstOrderDone,
          lstDetail,
          // user.fullName,
        ));
      } else {
        emit(HomeItemsLoadedState(false, 'Tải Menu thất bại'));
        emit(HomeOrdersLoadedState(
          '',
          const <OrderModel>[],
          '',
          const <OrderModel>[],
          const <OrderDetailModel>[],
          // user.fullName,
        ));
      }
    } catch (e) {
      log(e.toString());
      emit(HomeErrorState('Lỗi'));
    }
  }

  void _onOrderChange(
      HomeOrderChangeEvent event, Emitter<HomeState> emit) async {
    emit(HomeOrdersChangedState(event.orderId, event.lstOrderDetails));
  }

  void _onOrderDoneChange(
      HomeOrderDoneChangeEvent event, Emitter<HomeState> emit) async {
    emit(HomeOrdersDoneChangedState(event.orderId, event.lstOrderDetails));
  }

  void _onOrderPin(HomeOrderPinEvent event, Emitter<HomeState> emit) {
    var pinOrder = event.order;
    if (pinOrder != null) {
      List<OrderModel> lstOrderUnpinned =
          event.lstOrders.where((x) => x.id != pinOrder.id).toList();
      lstOrderUnpinned.sort((a, b) => a.orderNumber!.compareTo(b.orderNumber!));
      var lstOrderNew = <OrderModel>[];
      lstOrderNew.add(pinOrder);
      lstOrderNew.addAll(lstOrderUnpinned);
      emit(HomeOrdersPinnedState(event.order, lstOrderNew));
    } else {
      List<OrderModel> lstOrders = event.lstOrders;
      lstOrders.sort((a, b) => a.orderNumber!.compareTo(b.orderNumber!));
      emit(HomeOrdersPinnedState(pinOrder, event.lstOrders));
    }
  }

  void _onItemCheckboxChange(
      HomeItemCheckboxChangeEvent event, Emitter<HomeState> emit) async {
    emit(HomeItemCheckboxChangedState(event.check));
  }

  void _onOrderSubmit(
      HomeOrderSubmitEvent event, Emitter<HomeState> emit) async {
    emit(HomeUpdateLoadingState(true, 'Đang tải...'));
    try {
      var pinnedOrder = event.pinnedOrder;
      if (pinnedOrder == event.selectedOrder) {
        pinnedOrder = '';
      }
      List<OrderDetailModel> lstDetails = event.lstDetails;
      if (event.isNew) {
        var res = await _orderRepo.complete(event.selectedOrder);
        if (res!.isNotEmpty) {
          List<OrderModel> lstOrdersOld = event.lstOrders;
          List<OrderModel> lstOrdersNew =
              lstOrdersOld.where((x) => x.id != event.selectedOrder).toList();
          String selOrder = '';
          if (lstOrdersNew.isNotEmpty) {
            selOrder = lstOrdersNew[0].id!;
            lstDetails = lstOrdersNew[0].orderDetails!;
          } else {
            selOrder = '';
            lstDetails = <OrderDetailModel>[];
          }
          List<OrderModel> lstOrdersDone = event.lstOrdersDone;
          if (lstOrdersDone.isEmpty) {
            lstOrdersDone = <OrderModel>[];
          }
          lstOrdersDone
              .add(lstOrdersOld.firstWhere((x) => x.id == event.selectedOrder));
          lstOrdersDone
              .sort((a, b) => b.dateCreated!.compareTo(a.dateCreated!));
          var selOrderDone = event.selectedOrderDone;
          if (lstOrdersDone.length == 1) {
            selOrderDone = lstOrdersDone[0].id!;
          }

          emit(HomeOrderSubmitSuccessState(
            selOrder,
            lstOrdersNew,
            selOrderDone,
            lstOrdersDone,
            lstDetails,
            pinnedOrder,
          ));
        }
      } else {
        var res = await _orderRepo.uncomplete(event.selectedOrderDone);
        if (res!.isNotEmpty) {
          List<OrderModel> lstOrdersDoneOld = event.lstOrdersDone;
          List<OrderModel> lstOrdersDoneNew = lstOrdersDoneOld
              .where((x) => x.id != event.selectedOrderDone)
              .toList();
          String selOrderDone = '';
          if (lstOrdersDoneNew.isNotEmpty) {
            selOrderDone = lstOrdersDoneNew[0].id!;
            lstDetails = lstOrdersDoneNew[0].orderDetails!;
          } else {
            selOrderDone = '';
            lstDetails = <OrderDetailModel>[];
          }
          List<OrderModel> lstOrders = event.lstOrders;
          if (lstOrders.isEmpty) {
            lstOrders = <OrderModel>[];
          }
          lstOrders.add(lstOrdersDoneOld
              .firstWhere((x) => x.id == event.selectedOrderDone));
          lstOrders.sort((a, b) => a.dateCreated!.compareTo(b.dateCreated!));
          var selOrder = event.selectedOrder;
          if (lstOrders.length == 1) {
            selOrder = lstOrders[0].id!;
          }

          emit(HomeOrderSubmitSuccessState(
            selOrder,
            lstOrders,
            selOrderDone,
            lstOrdersDoneNew,
            lstDetails,
            event.pinnedOrder,
          ));
        }
      }
    } catch (e) {
      log(e.toString());
      emit(
        HomeErrorState(
            'Không thể hoàn ${event.isNew ? 'thành' : 'tác'} Order này'),
      );
    }
  }

  void _onOrderTabChange(
      HomeOrderTabChangeEvent event, Emitter<HomeState> emit) {
    emit(HomeOrderTabChangedState(
        event.isNew, event.lstCurrentOrder, event.lstCurrentOrderDetail));
  }

  void _onListenRecieveNewOrder(
      HomeListenRecieveNewOrderEvent event, Emitter<HomeState> emit) async {
    var hubConnect = await _signalr.newConnect(HubSignalR.notificationHub);
    hubConnect!.on(MethodSignalR.newNotify, (data) {
      String json = jsonEncode(data);
      List<OrderModel> lstOrders = List<OrderModel>.from(
        jsonDecode(json).map((model) => OrderModel.fromJson(model)),
      );
      // log('hub: $json');
      add(HomeRecieveNewOrderEvent(lstOrders));
    });
  }

  void _onRecieveNewOrder(
      HomeRecieveNewOrderEvent event, Emitter<HomeState> emit) async {
    // Load List Item
    var lstItem = <ItemModel>[];
    var lstItemJson = await LocalStorage.getItem(KeyLS.items);
    if (lstItemJson != null) {
      var lstItemDecode = jsonDecode(lstItemJson);
      lstItem = List<ItemModel>.from(
        lstItemDecode.map((model) => ItemModel.fromJson(model)),
      );
    } else {
      lstItem = await _itemRepo.getAll();
    }
    List<OrderModel> lstOrder = _assignItemToOrder(event.lstOrder, lstItem);
    var lstDetail = <OrderDetailModel>[];
    if (lstOrder.isNotEmpty) {
      lstDetail = lstOrder[0].orderDetails!;
    }
    emit(HomeRecieveNewOrderState(lstOrder, lstDetail));
  }

  List<OrderModel> _assignItemToOrder(
      List<OrderModel> lstOrder, List<ItemModel> lstItem) {
    for (var order in lstOrder) {
      for (var detail in order.orderDetails!) {
        detail.item = lstItem.firstWhere((x) => x.id == detail.itemId);
        if (detail.description!.isNotEmpty) {
          detail.listDescription = List<DetailDctModel>.from(
            jsonDecode(detail.description!)
                .map((model) => DetailDctModel.fromJson(model)),
          );
        }
      }
    }
    return lstOrder;
  }
}
