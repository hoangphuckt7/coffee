// ignore_for_file: prefer_typing_uninitialized_variables

part of 'pick_table_bloc.dart';

@immutable
abstract class PickTableEvent {}

class InitialEvent extends PickTableEvent {}

class LoadDataEvent extends PickTableEvent {}

class LogoutEvent extends PickTableEvent {}

class ErrorEvent extends PickTableEvent {
  final errMsg;

  ErrorEvent(this.errMsg);
}

class UpdateLoadingEvent extends PickTableEvent {
  final isLoading;
  final labelLoading;

  UpdateLoadingEvent(this.isLoading, this.labelLoading);
}

class GoToChangeTableEvent extends PickTableEvent {}

class GoToOrderEvent extends PickTableEvent {}
