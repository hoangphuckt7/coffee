// ignore_for_file: prefer_typing_uninitialized_variables

part of 'pick_table_bloc.dart';

@immutable
abstract class PickTableEvent {}

class InitialEvent extends PickTableEvent {}

class LoadFloorTableEvent extends PickTableEvent {}

class ErrorEvent extends PickTableEvent {
  final errMsg;

  ErrorEvent(this.errMsg);
}

class ChangeFloorEvent extends PickTableEvent {
  final floor;

  ChangeFloorEvent(this.floor);
}

class ChangeTableEvent extends PickTableEvent {
  final table;

  ChangeTableEvent(this.table);
}
