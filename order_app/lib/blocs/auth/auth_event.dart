// ignore_for_file: must_be_immutable, prefer_typing_uninitialized_variables

part of 'auth_bloc.dart';

@immutable
abstract class AuthEvent {}

class AuthDataChangedEvent extends AuthEvent {
  final username;
  final password;

  AuthDataChangedEvent(this.username, this.password);
}

class AuthSubmittedEvent extends AuthEvent {
  final username;
  final password;

  AuthSubmittedEvent(this.username, this.password);
}

class AuthLoadUserInfoEvent extends AuthEvent {}

class AuthLogoutEvent extends AuthEvent {}
