// ignore_for_file: depend_on_referenced_packages

import 'dart:convert';
import 'dart:developer';

import 'package:bbc_order_mobile/models/order/detail_dct_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_create_model.dart';
import 'package:bbc_order_mobile/utils/const.dart';
import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';

part 'checkout_event.dart';
part 'checkout_state.dart';

class CheckoutBloc extends Bloc<CheckoutEvent, CheckoutState> {
  CheckoutBloc() : super(InitialState()) {
    on<ChangeQuantityEvent>(_onChangeQuantity);
    on<ChangeSugarEvent>(_onChangeSugar);
    on<ChangeIceEvent>(_onChangeIce);
    on<ChangeNoteEvent>(_onChangeNote);
    on<GoBackOrderEvent>(_onGoBackOrder);
  }

  void _onChangeQuantity(
      ChangeQuantityEvent event, Emitter<CheckoutState> emit) {
    try {
      OrderDetailCreateModel detail = event.detail;
      int step = event.step;

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
        } else if (step == -1) {
          detail.listDct?.removeLast();
        }
        detail.description = jsonEncode(detail.listDct);
      }
      log('detail.description: ${jsonEncode(detail.listDct)}');
      emit(ChangedQuantityState(detail));
    } catch (e) {
      emit(ErrorState(AppInfo.ErrMsg));
      log('OrderBloc - _onChangeQuantity - ${e.toString()}');
    }
  }

  void _onChangeSugar(ChangeSugarEvent event, Emitter<CheckoutState> emit) {}

  void _onChangeIce(ChangeIceEvent event, Emitter<CheckoutState> emit) {}

  void _onChangeNote(ChangeNoteEvent event, Emitter<CheckoutState> emit) {}

  void _onGoBackOrder(GoBackOrderEvent event, Emitter<CheckoutState> emit) {
    emit(GoBackOrderState());
  }
}
