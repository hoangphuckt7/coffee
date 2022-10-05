import 'package:bloc/bloc.dart';
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

  void _onLoginSubmitted(SubmittedEvent event, Emitter<LoginState> emit) {
    var errUsername = Validations.validUsername(event.username);
    var errPassword = Validations.validPassword(event.password);
    if (errUsername != null || errPassword != null) {
      emit(DataInvalidState(errUsername, errPassword));
    } else {
      emit(SubmitSuccessState());
    }
  }
}
