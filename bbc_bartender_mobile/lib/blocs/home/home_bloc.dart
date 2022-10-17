import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/models/item/item_model.dart';
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
  final ItemRepo _itemRepo;
  final OrderRepo _orderRepo;

  HomeBloc(this._itemRepo, this._orderRepo) : super(InitialState()) {
    on<LoadDataEvent>(_onLoadData);
    on<OrderChangeEvent>(_onOrderChange);
    // on<OrderScrollEvent>(_onScrollOrders);
  }

  void _onLoadData(LoadDataEvent event, Emitter<HomeState> emit) async {
    emit(ItemsLoadingState("Đang tải Menu..."));
    try {
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
        log(jsonEncode(lstOrder));
        emit(OrdersLoadedState(lstItem, lstOrder));
      } else {
        emit(ItemsLoadedState(false, 'Tải Menu thất bại'));
        emit(OrdersLoadedState(const <ItemModel>[], const <OrderModel>[]));
      }
    } catch (e) {
      log(e.toString());
      emit(ErrorState(e.toString()));
    }
  }

  void _onOrderChange(OrderChangeEvent event, Emitter<HomeState> emit) {
    event.lstOrderDetails;
  }

  // void _onScrollOrders(OrderScrollEvent event, Emitter<HomeState> emit) {
  //   emit(OrderScrolledState(event.showArrowTop, event.showArrowBot));
  // }
}
