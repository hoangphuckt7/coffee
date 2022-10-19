import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/models/item/item_model.dart';
import 'package:bbc_bartender_mobile/models/login/login_req_model.dart/login_req_model.dart';
import 'package:bbc_bartender_mobile/models/login/login_res_model/login_res_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_detail_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_model.dart';
import 'package:bbc_bartender_mobile/models/user/user_model.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/repositories/order_repo.dart';
import 'package:bbc_bartender_mobile/repositories/user_repo.dart';
import 'package:bbc_bartender_mobile/utils/const.dart';
import 'package:bbc_bartender_mobile/utils/local_storage.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

part 'home_event.dart';
part 'home_state.dart';

class HomeBloc extends Bloc<HomeEvent, HomeState> {
  final ItemRepo _itemRepo;
  final OrderRepo _orderRepo;
  HomeBloc(this._itemRepo, this._orderRepo) : super(InitialState()) {
    on<LoadDataEvent>(_onLoadData);
    on<OrderChangeEvent>(_onOrderChange);
    on<OrderPinEvent>(_onOrderPin);
    on<LogoutEvent>(_onLogout);
    // on<OrderScrollEvent>(_onScrollOrders);
  }

  void _onLoadData(LoadDataEvent event, Emitter<HomeState> emit) async {
    emit(ItemsLoadingState("Đang tải Menu..."));
    try {
      // lay thong tin user
      var userJson = await LocalStorage.getItem(KeyLS.login_resp);
      log('message : $userJson');
      var user = LoginResModel.fromJson(jsonDecode(userJson));
      emit(UserInfoLoadedState(user.fullName));
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
      // Load List Order
      if (lstItem.isNotEmpty) {
        emit(ItemsLoadedState(true, 'Tải Menu thành công'));
        emit(OrdersLoadingState("Đang tải Order..."));
        var lstOrder = await _orderRepo.getCurrentOrders();
        if (lstOrder.isNotEmpty) {
          for (var order in lstOrder) {
            for (var detail in order.orderDetails) {
              detail.item = lstItem.firstWhere((x) => x.id == detail.itemId);
            }
          }
          emit(OrdersLoadedState(lstOrder, lstOrder[0].orderDetails));
        } else {
          emit(ErrorState('Không có order'));
        }
      } else {
        emit(ItemsLoadedState(false, 'Tải Menu thất bại'));
        emit(OrdersLoadedState(
          const <OrderModel>[],
          const <OrderDetailModel>[],
        ));
      }
    } catch (e) {
      log(e.toString());
      emit(ErrorState('Lỗi'));
    }
  }

  void _onOrderChange(OrderChangeEvent event, Emitter<HomeState> emit) async {
    emit(OrdersLoadingState('Đang tải...'));
    // var lstItemJson = await LocalStorage.getItem(KeyLS.items);
    // var lstItem = List<ItemModel>.from(
    //   jsonDecode(lstItemJson).map((model) => ItemModel.fromJson(model)),
    // );
    // var lstDetail = event.lstOrderDetails;
    // for (var detail in lstDetail) {
    //   detail.item = lstItem.firstWhere((x) => x.id == detail.itemId);
    // }
    // log(jsonEncode(lstDetail));
    emit(OrdersChangedState(event.orderId, event.lstOrderDetails));
  }

  void _onOrderPin(OrderPinEvent event, Emitter<HomeState> emit) {
    emit(OrdersLoadingState('Đang tải...'));
    var pinOrder = event.order;
    if (pinOrder != null) {
      List<OrderModel> lstOrderUnpinned =
          event.lstOrders.where((x) => x.id != pinOrder.id).toList();
      lstOrderUnpinned.sort((a, b) => a.orderNumber!.compareTo(b.orderNumber!));
      var lstOrderNew = <OrderModel>[];
      lstOrderNew.add(pinOrder);
      lstOrderNew.addAll(lstOrderUnpinned);
      emit(OrdersPinnedState(event.order, lstOrderNew));
      return;
    }

    emit(OrdersPinnedState(pinOrder, event.lstOrders));
  }

  void _onLogout(LogoutEvent event, Emitter<HomeState> emit) async {
    await LocalStorage.removeAll();
    emit(LogoutState());
  }
  // void _onScrollOrders(OrderScrollEvent event, Emitter<HomeState> emit) {
  //   emit(OrderScrolledState(event.showArrowTop, event.showArrowBot));
  // }
}
