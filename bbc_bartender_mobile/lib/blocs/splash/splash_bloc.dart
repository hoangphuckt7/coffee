// ignore_for_file: depend_on_referenced_packages

import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:bbc_bartender_mobile/repositories/user_repo.dart';
import 'package:meta/meta.dart';

part 'splash_event.dart';
part 'splash_state.dart';

class SplashBloc extends Bloc<SplashEvent, SplashState> {
  final UserRepo _userRepo = UserRepo();
  SplashBloc() : super(InitialState()) {
    on<CheckLoginEvent>(_onCheckLogin);
  }

  void _onCheckLogin(CheckLoginEvent event, Emitter<SplashState> emit) async {
    emit(InitialState());
    try {
      var isLoginSuccess = await _userRepo.checkLogin();
      if (isLoginSuccess) {
        emit(LoginSuccessState());
      } else {
        emit(LoginFailState());
      }
    } catch (e) {
      log(e.toString());
      emit(LoginFailState());
    }
  }
}
