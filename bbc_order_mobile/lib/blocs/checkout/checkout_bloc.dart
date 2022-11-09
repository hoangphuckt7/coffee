// ignore_for_file: depend_on_referenced_packages

import 'dart:convert';
import 'dart:developer';

import 'package:bbc_order_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_create_model.dart';
import 'package:bbc_order_mobile/repositories/order_repo.dart';
import 'package:bbc_order_mobile/utils/const.dart';
import 'package:bloc/bloc.dart';
import 'package:flutter/material.dart';
import 'package:meta/meta.dart';

part 'checkout_event.dart';
part 'checkout_state.dart';

class CheckoutBloc extends Bloc<CheckoutEvent, CheckoutState> {
  final _orderRepo = OrderRepo();

  CheckoutBloc() : super(InitialState()) {
    on<ChangeQuantityEvent>(_onChangeQuantity);
    on<ChangeSugarEvent>(_onChangeSugar);
    on<ChangeIceEvent>(_onChangeIce);
    on<ChangeNoteEvent>(_onChangeNote);
    on<GoBackOrderEvent>(_onGoBackOrder);
    on<ConfirmOrderEvent>(_onConfirmOrder);
  }

  void _onChangeQuantity(
      ChangeQuantityEvent event, Emitter<CheckoutState> emit) {
    try {
      OrderDetailCreateModel detail = event.detail;
      int step = event.step;
      List<TextEditingController> lstController = event.listController;
      bool isUpdate = false;
      if (detail.quantity > 0) {
        detail.quantity += step;
        isUpdate = true;
      } else if (detail.quantity == 0 && step == 1) {
        detail.quantity += step;
        isUpdate = true;
      }
      if (isUpdate) {
        if (step == 1) {
          detail.listDct?.add(DetailDctModel(100, 100, null));
          lstController.add(TextEditingController());
        } else if (step == -1) {
          detail.listDct?.removeLast();
          lstController.removeLast();
        }
        detail.description = jsonEncode(detail.listDct);
      }

      emit(ChangedQuantityState(detail, lstController));
    } catch (e) {
      emit(ErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeQuantity - ${e.toString()}');
    }
  }

  void _onChangeSugar(ChangeSugarEvent event, Emitter<CheckoutState> emit) {
    try {
      OrderDetailCreateModel detail = event.detail;
      int index = event.indexDct;
      int step = event.step;

      int newVal = detail.listDct![index].Sugar! + step;
      if (newVal >= 0 && newVal <= 200) {
        detail.listDct![index].Sugar = newVal;
      }
      detail.description = jsonEncode(detail.listDct);

      emit(ChangedSugarState(detail));
    } catch (e) {
      emit(ErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeSugar - ${e.toString()}');
    }
  }

  void _onChangeIce(ChangeIceEvent event, Emitter<CheckoutState> emit) {
    try {
      OrderDetailCreateModel detail = event.detail;
      int index = event.indexDct;
      int step = event.step;

      int newVal = detail.listDct![index].Ice! + step;
      if (newVal >= 0 && newVal <= 200) {
        detail.listDct![index].Ice = newVal;
      }
      detail.description = jsonEncode(detail.listDct);

      emit(ChangedIceState(detail));
    } catch (e) {
      emit(ErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeIce - ${e.toString()}');
    }
  }

  void _onChangeNote(ChangeNoteEvent event, Emitter<CheckoutState> emit) {
    try {
      OrderDetailCreateModel detail = event.detail;
      int index = event.indexDct;
      String? note = event.note;

      detail.listDct![index].Note = note;
      detail.description = jsonEncode(detail.listDct);

      emit(ChangedNoteState(detail));

      log('detail.description: ${detail.description}');
    } catch (e) {
      emit(ErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeNote - ${e.toString()}');
    }
  }

  void _onGoBackOrder(GoBackOrderEvent event, Emitter<CheckoutState> emit) {
    emit(GoBackOrderState());
  }

  void _onConfirmOrder(
      ConfirmOrderEvent event, Emitter<CheckoutState> emit) async {
    try {
      var resp = await _orderRepo.create(event.order);
      if (resp is bool) {
        if (resp) {
          emit(GoToPickTableState());
        } else {
          emit(ErrorState('Lỗi! Order thất bại.'));
        }
      } else if (resp is String) {
        emit(ErrorState(resp));
      }
    } catch (e) {
      emit(ErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onConfirmOrder - ${e.toString()}');
    }
  }
}
