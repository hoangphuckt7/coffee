// ignore_for_file: depend_on_referenced_packages

import 'dart:convert';
import 'dart:developer';

import 'package:bartender_app/models/login/login_res_model/login_res_model.dart';
import 'package:bartender_app/utils/const.dart';
import 'package:bartender_app/utils/local_storage.dart';
import 'package:bloc/bloc.dart';
import 'package:bartender_app/models/login/login_req_model.dart/login_req_model.dart';
import 'package:bartender_app/repositories/user_repo.dart';
import 'package:bartender_app/utils/validation.dart';
import 'package:flutter/material.dart';

part 'auth_event.dart';
part 'auth_state.dart';

class AuthBloc extends Bloc<AuthEvent, AuthState> {
  final _userRepo = UserRepo();
  AuthBloc() : super(InitialState()) {
    on<DataChangedEvent>(_onDataChanged);
    on<SubmittedEvent>(_onLoginSubmitted);
    on<LoadUserInfoEvent>(_onLoadUserInfo);
    on<LogoutEvent>(_onLogout);
  }

  void _onDataChanged(DataChangedEvent event, Emitter<AuthState> emit) {
    emit(SubmittingState());
    var errUsername = Validations.validUsername(event.username);
    var errPassword = Validations.validPassword(event.password);
    if (errUsername != null || errPassword != null) {
      emit(DataInvalidState(errUsername, errPassword));
      return;
    }
    emit(InitialState());
  }

  void _onLoginSubmitted(SubmittedEvent event, Emitter<AuthState> emit) async {
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

  void _onLoadUserInfo(LoadUserInfoEvent event, Emitter<AuthState> emit) async {
    // lay thong tin user --------------------------------------------------
    var userJson = await LocalStorage.getItem(KeyLS.user_json);
    log('userJson: $userJson');
    var user = LoginResModel.fromJson(jsonDecode(userJson));
    log('fullName: ${user.fullName!}');
    emit(LoadedUserInfoState(user.fullName!));
  }

  void _onLogout(LogoutEvent event, Emitter<AuthState> emit) async {
    await LocalStorage.removeAll();
    emit(LogoutState());
  }
}
