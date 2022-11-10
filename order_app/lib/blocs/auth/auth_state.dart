// ignore_for_file: prefer_typing_uninitialized_variables

part of 'auth_bloc.dart';

@immutable
abstract class AuthState {}

class AuthInitialState extends AuthState {}

class AuthDataInvalidState extends AuthState {
  final errUsername;
  final errPassword;

  AuthDataInvalidState(this.errUsername, this.errPassword);
}

class AuthSubmitSuccessState extends AuthState {}

class AuthSubmittingState extends AuthState {}

class AuthSubmitFailState extends AuthState {
  final errMsg;

  AuthSubmitFailState(this.errMsg);
}

class AuthLoadedUserInfoState extends AuthState {
  final fullName;

  AuthLoadedUserInfoState(this.fullName);
}

class AuthLogoutState extends AuthState {}
