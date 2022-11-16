// ignore_for_file: prefer_typing_uninitialized_variables

part of 'pick_table_bloc.dart';

@immutable
abstract class PickTableEvent {}

class PTInitialEvent extends PickTableEvent {}

class PTErrorEvent extends PickTableEvent {
  final errMsg;

  PTErrorEvent(this.errMsg);
}

class PTLoadFloorTableEvent extends PickTableEvent {
  final floor;
  final table;

  PTLoadFloorTableEvent(this.floor, this.table);
}

class PTChangeFloorEvent extends PickTableEvent {
  final floor;

  PTChangeFloorEvent(this.floor);
}

class PTChangeTableEvent extends PickTableEvent {
  final table;

  PTChangeTableEvent(this.table);
}

class PTShowPopupConfirmExitEvent extends PickTableEvent {
  final isVisible;

  PTShowPopupConfirmExitEvent(this.isVisible);
}
