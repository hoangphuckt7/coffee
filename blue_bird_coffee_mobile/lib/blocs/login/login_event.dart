// ignore_for_file: must_be_immutable

part of 'login_bloc.dart';

@immutable
abstract class LoginEvent {}

class DataChangedEvent extends LoginEvent {
  final username;
  final password;

  DataChangedEvent(this.username, this.password);
}

class SubmittedEvent extends LoginEvent {
  final context;
  final username;
  final password;

  SubmittedEvent(this.context, this.username, this.password);
}
