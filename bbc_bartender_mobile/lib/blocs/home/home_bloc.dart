import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/api/signalr.dart';
import 'package:bbc_bartender_mobile/models/item/item_model.dart';
import 'package:bbc_bartender_mobile/models/login/login_res_model/login_res_model.dart';
import 'package:bbc_bartender_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_detail_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_model.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/repositories/order_repo.dart';
import 'package:bbc_bartender_mobile/utils/const.dart';
import 'package:bbc_bartender_mobile/utils/local_storage.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

part 'home_event.dart';
part 'home_state.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  final ItemRepo _itemRepo = ItemRepo();
  final OrderRepo _orderRepo = OrderRepo();
  final SignalR _signalr = SignalR();
  HomeBloc() : super(InitialState()) {
    on<LoadDataEvent>(_onLoadData);
    on<OrderChangeEvent>(_onOrderChange);
    on<OrderDoneChangeEvent>(_onOrderDoneChange);
    on<OrderPinEvent>(_onOrderPin);
    on<ItemCheckboxChangeEvent>(_onItemCheckboxChange);
    on<OrderTabChangeEvent>(_onOrderTabChange);
    on<OrderSubmitEvent>(_onOrderSubmit);
    on<ListenRecieveNewOrderEvent>(_onListenRecieveNewOrder);
    on<RecieveNewOrderEvent>(_onRecieveNewOrder);
  }

  void _onLoadData(LoadDataEvent event, Emitter<HomeState> emit) async {
    emit(UpdateLoadingState(true, "Đang tải Menu..."));

    try {
      // // lay thong tin user --------------------------------------------------
      // var userJson = await LocalStorage.getItem(KeyLS.user_json);
      // log('userJson: $userJson');
      // var user = LoginResModel.fromJson(jsonDecode(userJson));
      // log('fullName: ${user.fullName!}');
      // // emit(UserInfoLoadedState(user.fullName!));

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
        emit(ItemsLoadedState(true, 'Tải Menu thành công'));
        emit(UpdateLoadingState(true, "Đang tải Order..."));
        var barOrder = await _orderRepo.getBartenderOrders();

        String selOrder = '';
        var lstOrder = <OrderModel>[];
        var lstDetail = <OrderDetailModel>[];
        if (barOrder!.listOrderNew.isNotEmpty) {
          lstOrder = _convertLstOrder(barOrder.listOrderNew, lstItem);
          selOrder = lstOrder[0].id!;
          lstDetail = lstOrder[0].orderDetails!;
        }

        String selOrderDone = '';
        var lstOrderDone = <OrderModel>[];
        if (barOrder.listOrderCompleted.isNotEmpty) {
          lstOrderDone = _convertLstOrder(barOrder.listOrderCompleted, lstItem);
          selOrderDone = lstOrderDone[0].id!;
        }

        emit(OrdersLoadedState(
          selOrder,
          lstOrder,
          selOrderDone,
          lstOrderDone,
          lstDetail,
          // user.fullName,
        ));
      } else {
        emit(ItemsLoadedState(false, 'Tải Menu thất bại'));
        emit(OrdersLoadedState(
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
      emit(ErrorState('Lỗi'));
    }
  }

  void _onOrderChange(OrderChangeEvent event, Emitter<HomeState> emit) async {
    emit(OrdersChangedState(event.orderId, event.lstOrderDetails));
  }

  void _onOrderDoneChange(
      OrderDoneChangeEvent event, Emitter<HomeState> emit) async {
    emit(OrdersDoneChangedState(event.orderId, event.lstOrderDetails));
  }

  void _onOrderPin(OrderPinEvent event, Emitter<HomeState> emit) {
    var pinOrder = event.order;
    if (pinOrder != null) {
      List<OrderModel> lstOrderUnpinned =
          event.lstOrders.where((x) => x.id != pinOrder.id).toList();
      lstOrderUnpinned.sort((a, b) => a.orderNumber!.compareTo(b.orderNumber!));
      var lstOrderNew = <OrderModel>[];
      lstOrderNew.add(pinOrder);
      lstOrderNew.addAll(lstOrderUnpinned);
      emit(OrdersPinnedState(event.order, lstOrderNew));
    } else {
      List<OrderModel> lstOrders = event.lstOrders;
      lstOrders.sort((a, b) => a.orderNumber!.compareTo(b.orderNumber!));
      emit(OrdersPinnedState(pinOrder, event.lstOrders));
    }
  }

  void _onItemCheckboxChange(
      ItemCheckboxChangeEvent event, Emitter<HomeState> emit) async {
    emit(ItemCheckboxChangedState(event.check));
  }

  void _onOrderSubmit(OrderSubmitEvent event, Emitter<HomeState> emit) async {
    emit(UpdateLoadingState(true, 'Đang tải...'));
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
          var selOrderDone = event.selectedOrderDone;
          if (lstOrdersDone.length == 1) {
            selOrderDone = lstOrdersDone[0].id!;
          }

          emit(OrderSubmitSuccessState(
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
          var selOrder = event.selectedOrder;
          if (lstOrders.length == 1) {
            selOrder = lstOrders[0].id!;
          }

          emit(OrderSubmitSuccessState(
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
        ErrorState('Không thể hoàn ${event.isNew ? 'thành' : 'tác'} Order này'),
      );
    }
  }

  void _onOrderTabChange(OrderTabChangeEvent event, Emitter<HomeState> emit) {
    emit(OrderTabChangedState(
        event.isNew, event.lstCurrentOrder, event.lstCurrentOrderDetail));
  }

  void _onListenRecieveNewOrder(
      ListenRecieveNewOrderEvent event, Emitter<HomeState> emit) async {
    var hubConnect = await _signalr.newConnect(HubSignalR.notificationHub);
    hubConnect!.on(MethodSignalR.newNotify, (data) {
      String json = jsonEncode(data);
      List<OrderModel> lstOrders = List<OrderModel>.from(
        jsonDecode(json).map((model) => OrderModel.fromJson(model)),
      );
      log('hub: $json');
      add(RecieveNewOrderEvent(lstOrders));
    });
  }

  void _onRecieveNewOrder(
      RecieveNewOrderEvent event, Emitter<HomeState> emit) async {
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
    List<OrderModel> lstOrder = _convertLstOrder(event.lstOrder, lstItem);
    var lstDetail = <OrderDetailModel>[];
    if (lstOrder.isNotEmpty) {
      lstDetail = lstOrder[0].orderDetails!;
    }
    emit(RecieveNewOrderState(lstOrder, lstDetail));
  }

  List<OrderModel> _convertLstOrder(
      List<OrderModel> lstOrder, List<ItemModel> lstItem) {
    var count = 0;
    for (var order in lstOrder) {
      var lstOD = <OrderDetailModel>[];

      for (var detail in order.orderDetails!) {
        detail.item = lstItem.firstWhere((x) => x.id == detail.itemId);
        if (detail.description!.isNotEmpty) {
          var lstDct = List<DetailDctModel>.from(
            jsonDecode(detail.description!)
                .map((model) => DetailDctModel.fromJson(model)),
          );
          for (var dct in lstDct) {
            var detailClone = OrderDetailModel.clone(detail);
            detailClone.dctModel = dct;
            detailClone.quantity = 1;
            detailClone.uniqueKey = count;
            lstOD.add(detailClone);
            count++;
          }
        } else {
          detail.uniqueKey = count;
          lstOD.add(detail);
          count++;
        }
      }
      order.orderDetails = lstOD;
    }
    return lstOrder;
  }
}
