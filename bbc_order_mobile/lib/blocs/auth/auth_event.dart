// ignore_for_file: must_be_immutable, prefer_typing_uninitialized_variables

part of 'auth_bloc.dart';

@immutable
abstract class AuthEvent {}

class DataChangedEvent extends AuthEvent {
  final username;
  final password;

  DataChangedEvent(this.username, this.password);
}

class SubmittedEvent extends AuthEvent {
  final username;
  final password;

  SubmittedEvent(this.username, this.password);
}

class LoadUserInfoEvent extends AuthEvent {}

class LogoutEvent extends AuthEvent {}
