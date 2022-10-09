// ignore_for_file: must_be_immutable

part of 'login_bloc.dart';

@immutable
abstract class LoginState {}

class InitialState extends LoginState {}

class DataInvalidState extends LoginState {
  final errUsername;
  final errPassword;

  DataInvalidState(this.errUsername, this.errPassword);
}

class SubmitSuccessState extends LoginState {}

class SubmittingState extends LoginState {}

class SubmitFailState extends LoginState {
  final errMsg;

  SubmitFailState(this.errMsg);
}
