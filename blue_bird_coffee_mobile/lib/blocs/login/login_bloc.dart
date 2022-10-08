import 'dart:convert';

import 'package:bloc/bloc.dart';
import 'package:blue_bird_coffee_mobile/models/login/login_req_model.dart/login_req_model.dart';
import 'package:blue_bird_coffee_mobile/models/login/login_res_model/login_res_model.dart';
import 'package:blue_bird_coffee_mobile/repositories/user_repo.dart';
import 'package:blue_bird_coffee_mobile/utils/const.dart';
import 'package:blue_bird_coffee_mobile/utils/local_storage.dart';
import 'package:blue_bird_coffee_mobile/utils/validation.dart';
import 'package:flutter/material.dart';
import 'package:meta/meta.dart';

part 'login_event.dart';
part 'login_state.dart';

class LoginBloc extends Bloc<LoginEvent, LoginState> {
  LoginBloc() : super(InitialState()) {
    on<DataChangedEvent>(_onDataChanged);
    on<SubmittedEvent>(_onLoginSubmitted);
  }

  void _onDataChanged(DataChangedEvent event, Emitter<LoginState> emit) {
    var errUsername = Validations.validUsername(event.username);
    var errPassword = Validations.validPassword(event.password);
    if (errUsername != null || errPassword != null) {
      emit(DataInvalidState(errUsername, errPassword));
      return;
    }
    emit(InitialState());
  }

  void _onLoginSubmitted(SubmittedEvent event, Emitter<LoginState> emit) async {
    var errUsername = Validations.validUsername(event.username);
    var errPassword = Validations.validPassword(event.password);
    if (errUsername != null || errPassword != null) {
      emit(DataInvalidState(errUsername, errPassword));
    } else {
      var lsonReqModel = LoginReqModel(
        event.username.toString(),
        event.password.toString(),
      );
      var resp = await UserRepo.login(lsonReqModel);
      if (resp != null) {
        await LocalStorage.setItem(KeyLS.token, resp.token);
        await LocalStorage.setItem(KeyLS.login_info, lsonReqModel.toJson());
        emit(SubmitSuccessState());
      } else {}
    }
  }
}
