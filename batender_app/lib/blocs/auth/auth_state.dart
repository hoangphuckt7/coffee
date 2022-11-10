// ignore_for_file: prefer_typing_uninitialized_variables

part of 'auth_bloc.dart';

@immutable
abstract class AuthState {}

class InitialState extends AuthState {}

class DataInvalidState extends AuthState {
  final errUsername;
  final errPassword;

  DataInvalidState(this.errUsername, this.errPassword);
}

class SubmitSuccessState extends AuthState {}

class SubmittingState extends AuthState {}

class SubmitFailState extends AuthState {
  final errMsg;

  SubmitFailState(this.errMsg);
}

class LoadedUserInfoState extends AuthState {
  final fullName;

  LoadedUserInfoState(this.fullName);
}

class LogoutState extends AuthState {}
