// ignore_for_file: depend_on_referenced_packages

import 'dart:convert';
import 'dart:developer';

import 'package:orderr_app/models/login/login_res_model/login_res_model.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:orderr_app/utils/local_storage.dart';
import 'package:bloc/bloc.dart';
import 'package:orderr_app/models/login/login_req_model.dart/login_req_model.dart';
import 'package:orderr_app/repositories/user_repo.dart';
import 'package:orderr_app/utils/validation.dart';
import 'package:flutter/material.dart';

part 'auth_event.dart';
part 'auth_state.dart';

class AuthBloc extends Bloc<AuthEvent, AuthState> {
  final _userRepo = UserRepo();
  AuthBloc() : super(AuthInitialState()) {
    on<AuthDataChangedEvent>(_onDataChanged);
    on<AuthSubmittedEvent>(_onLoginSubmitted);
    on<AuthLoadUserInfoEvent>(_onLoadUserInfo);
    on<AuthLogoutEvent>(_onLogout);
  }

  void _onDataChanged(AuthDataChangedEvent event, Emitter<AuthState> emit) {
    emit(AuthSubmittingState());
    var errUsername = Validations.validUsername(event.username);
    var errPassword = Validations.validPassword(event.password);
    if (errUsername != null || errPassword != null) {
      emit(AuthDataInvalidState(errUsername, errPassword));
      return;
    }
    emit(AuthInitialState());
  }

  void _onLoginSubmitted(
      AuthSubmittedEvent event, Emitter<AuthState> emit) async {
    emit(AuthSubmittingState());
    var errUsername = Validations.validUsername(event.username);
    var errPassword = Validations.validPassword(event.password);
    if (errUsername != null || errPassword != null) {
      emit(AuthDataInvalidState(errUsername, errPassword));
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
            emit(AuthSubmitFailState(resp));
          } else {
            emit(AuthSubmitSuccessState());
          }
        }
      } catch (e) {
        log(e.toString());
        emit(AuthSubmitFailState(e.toString()));
      }
    }
  }

  void _onLoadUserInfo(
      AuthLoadUserInfoEvent event, Emitter<AuthState> emit) async {
    // lay thong tin user --------------------------------------------------
    var userJson = await LocalStorage.getItem(KeyLS.user_json);
    log('userJson: $userJson');
    var user = LoginResModel.fromJson(jsonDecode(userJson));
    log('fullName: ${user.fullName!}');
    emit(AuthLoadedUserInfoState(user.fullName!));
  }

  void _onLogout(AuthLogoutEvent event, Emitter<AuthState> emit) async {
    await LocalStorage.removeAll();
    emit(AuthLogoutState());
  }
}
