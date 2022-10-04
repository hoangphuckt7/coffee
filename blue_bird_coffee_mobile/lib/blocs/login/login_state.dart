part of 'login_bloc.dart';

@immutable
abstract class LoginState {}

class LoginInitial extends LoginState {}

class LoginUsernameInvalid extends LoginState {
  final errMsg;
  LoginUsernameInvalid(this.errMsg);
}

class LoginUsernameValid extends LoginState {}

class LoginPasswordInvalid extends LoginState {
  final errMsg;
  LoginPasswordInvalid(this.errMsg);
}

class LoginPasswordValid extends LoginState {}

class LoginError extends LoginState {
  final errMsg;
  LoginError(this.errMsg);
}

class LoginLoading extends LoginState {}
