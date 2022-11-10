// ignore_for_file: prefer_typing_uninitialized_variables

part of 'change_table_bloc.dart';

@immutable
abstract class ChangeTableEvent {}

class CTInitialEvent extends ChangeTableEvent {}

class CTErrorEvent extends ChangeTableEvent {
  final errMsg;

  CTErrorEvent(this.errMsg);
}

class CTLoadFloorTableEvent extends ChangeTableEvent {}
