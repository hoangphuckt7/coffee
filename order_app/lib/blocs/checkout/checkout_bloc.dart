// ignore_for_file: depend_on_referenced_packages, unnecessary_import

import 'dart:convert';
import 'dart:developer';

import 'package:orderr_app/models/order/detail_dct_model.dart';
import 'package:orderr_app/models/order/order_detail_create_model.dart';
import 'package:orderr_app/repositories/order_repo.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:bloc/bloc.dart';
import 'package:flutter/material.dart';
import 'package:meta/meta.dart';

part 'checkout_event.dart';
part 'checkout_state.dart';

class CheckoutBloc extends Bloc<CheckoutEvent, CheckoutState> {
  final _orderRepo = OrderRepo();

  CheckoutBloc() : super(COInitialState()) {
    on<COChangeQuantityEvent>(_onChangeQuantity);
    on<COChangeSugarEvent>(_onChangeSugar);
    on<COChangeIceEvent>(_onChangeIce);
    on<COChangeNoteEvent>(_onChangeNote);
    on<COGoBackOrderEvent>(_onGoBackOrder);
    on<COConfirmOrderEvent>(_onConfirmOrder);
    on<COShowPopupConfirmCheckoutEvent>(_onShowPopupConfirmCheckout);
  }

  void _onChangeQuantity(
      COChangeQuantityEvent event, Emitter<CheckoutState> emit) {
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

      emit(COChangedQuantityState(detail, lstController));
    } catch (e) {
      emit(COErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeQuantity - ${e.toString()}');
    }
  }

  void _onChangeSugar(COChangeSugarEvent event, Emitter<CheckoutState> emit) {
    try {
      OrderDetailCreateModel detail = event.detail;
      int index = event.indexDct;
      int step = event.step;

      int newVal = detail.listDct![index].Sugar! + step;
      if (newVal >= 0 && newVal <= 200) {
        detail.listDct![index].Sugar = newVal;
      }
      detail.description = jsonEncode(detail.listDct);

      emit(COChangedSugarState(detail));
    } catch (e) {
      emit(COErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeSugar - ${e.toString()}');
    }
  }

  void _onChangeIce(COChangeIceEvent event, Emitter<CheckoutState> emit) {
    try {
      OrderDetailCreateModel detail = event.detail;
      int index = event.indexDct;
      int step = event.step;

      int newVal = detail.listDct![index].Ice! + step;
      if (newVal >= 0 && newVal <= 200) {
        detail.listDct![index].Ice = newVal;
      }
      detail.description = jsonEncode(detail.listDct);

      emit(COChangedIceState(detail));
    } catch (e) {
      emit(COErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeIce - ${e.toString()}');
    }
  }

  void _onChangeNote(COChangeNoteEvent event, Emitter<CheckoutState> emit) {
    try {
      OrderDetailCreateModel detail = event.detail;
      int index = event.indexDct;
      String? note = event.note;

      detail.listDct![index].Note = note;
      detail.description = jsonEncode(detail.listDct);

      emit(COChangedNoteState(detail));

      log('detail.description: ${detail.description}');
    } catch (e) {
      emit(COErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeNote - ${e.toString()}');
    }
  }

  void _onGoBackOrder(COGoBackOrderEvent event, Emitter<CheckoutState> emit) {
    emit(COGoBackOrderState());
  }

  void _onConfirmOrder(
      COConfirmOrderEvent event, Emitter<CheckoutState> emit) async {
    emit(COUpdatedLoadingState(true, 'Đang order...'));
    try {
      var resp = await _orderRepo.create(event.order);
      if (resp is bool) {
        if (resp) {
          emit(COGoToPickTableState());
        } else {
          emit(COErrorState('Lỗi! Order thất bại.'));
        }
      } else if (resp is String) {
        emit(COErrorState(resp));
      }
    } catch (e) {
      emit(COErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onConfirmOrder - ${e.toString()}');
    }
  }

  void _onShowPopupConfirmCheckout(
      COShowPopupConfirmCheckoutEvent event, Emitter<CheckoutState> emit) {
    emit(COShowConfirmCheckoutPopupState(event.isVisible));
  }
}
