import 'package:bloc/bloc.dart';
import 'package:blue_bird_coffee_mobile/repositories/user_repo.dart';
import 'package:meta/meta.dart';
import 'dart:async';

part 'auth_event.dart';
part 'auth_state.dart';

class AuthBloc extends Bloc<AuthEvent, AuthState> {
  var userRepo = new UserRepo();

  AuthBloc(this.userRepo) : super(InitState()) {
    on<AuthEvent>((event, emit) {
      emit(InitState());
    });
  }
}
