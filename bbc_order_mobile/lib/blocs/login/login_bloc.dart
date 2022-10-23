import 'dart:convert';
import 'dart:developer';

import 'package:bbc_order_mobile/repositories/item_repo.dart';
import 'package:bloc/bloc.dart';
import 'package:bbc_order_mobile/models/login/login_req_model.dart/login_req_model.dart';
import 'package:bbc_order_mobile/repositories/user_repo.dart';
import 'package:bbc_order_mobile/utils/validation.dart';
import 'package:flutter/material.dart';

part 'login_event.dart';
part 'login_state.dart';

class LoginBloc extends Bloc<LoginEvent, LoginState> {
  final _userRepo = UserRepo();
  LoginBloc() : super(InitialState()) {
    on<DataChangedEvent>(_onDataChanged);
    on<SubmittedEvent>(_onLoginSubmitted);
  }

  void _onDataChanged(DataChangedEvent event, Emitter<LoginState> emit) {
    emit(SubmittingState());
    var errUsername = Validations.validUsername(event.username);
    var errPassword = Validations.validPassword(event.password);
    if (errUsername != null || errPassword != null) {
      emit(DataInvalidState(errUsername, errPassword));
      return;
    }
    emit(InitialState());
  }

  void _onLoginSubmitted(SubmittedEvent event, Emitter<LoginState> emit) async {
    emit(SubmittingState());
    var errUsername = Validations.validUsername(event.username);
    var errPassword = Validations.validPassword(event.password);
    if (errUsername != null || errPassword != null) {
      emit(DataInvalidState(errUsername, errPassword));
    } else {
      // LocalStorage.setItem(KeyLS.login_info, "alo");
      // emit(SubmitSuccessState());
      // return;
      // await Future.delayed(Duration(seconds: 5));
      var model = LoginReqModel(
        event.username.toString(),
        event.password.toString(),
      );
      try {
        var resp = await _userRepo.login(model);
        if (resp != null) {
          if (resp is String) {
            log(resp);
            emit(SubmitFailState(resp));
          } else {
            emit(SubmitSuccessState());
          }
        }
      } catch (e) {
        log(e.toString());
        emit(SubmitFailState(e.toString()));
      }
    }
  }
}
