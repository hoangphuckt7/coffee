// ignore_for_file: depend_on_referenced_packages

import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:orderr_app/repositories/user_repo.dart';
import 'package:meta/meta.dart';

part 'splash_event.dart';
part 'splash_state.dart';

class SplashBloc extends Bloc<SplashEvent, SplashState> {
  final UserRepo _userRepo = UserRepo();
  SplashBloc() : super(SPInitialState()) {
    on<SPCheckLoginEvent>(_onCheckLogin);
  }

  void _onCheckLogin(SPCheckLoginEvent event, Emitter<SplashState> emit) async {
    emit(SPInitialState());
    try {
      var isLoginSuccess = await _userRepo.checkLogin();
      if (isLoginSuccess) {
        emit(SPLoginSuccessState());
      } else {
        emit(SPLoginFailState());
      }
    } catch (e) {
      log(e.toString());
      emit(SPLoginFailState());
    }
  }
}
