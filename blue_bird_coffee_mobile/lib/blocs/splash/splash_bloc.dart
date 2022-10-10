import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:blue_bird_coffee_mobile/repositories/user_repo.dart';
import 'package:blue_bird_coffee_mobile/utils/const.dart';
import 'package:blue_bird_coffee_mobile/utils/local_storage.dart';
import 'package:meta/meta.dart';

part 'splash_event.dart';
part 'splash_state.dart';

class SplashBloc extends Bloc<SplashEvent, SplashState> {
  final UserRepo _userRepo;
  SplashBloc(this._userRepo) : super(InitialState()) {
    on<CheckLoginEvent>(_onCheckLogin);
  }

  void _onCheckLogin(CheckLoginEvent event, Emitter<SplashState> emit) async {
    emit(InitialState());
    await Future.delayed(Duration(seconds: 2));
    log('message0');
    try {
      // var a = await _userRepo.checkLogin();
      var loginInfo = await LocalStorage.getItem(KeyLS.login_info);
      if (loginInfo == null) {
        log('message1');
        emit(LoginFailState());
      }
      else {
        await LocalStorage.removeItem(KeyLS.login_info);
        emit(LoginSuccessState());

      }
    } catch (e) {
      print(e);
      // emit(ErrorState("Lỗi"));
    }
  }
}
