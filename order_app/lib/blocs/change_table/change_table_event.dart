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

class CTChangeFloorOldEvent extends ChangeTableEvent {
  final floor;

  CTChangeFloorOldEvent(this.floor);
}

class CTChangeFloorNewEvent extends ChangeTableEvent {
  final floor;

  CTChangeFloorNewEvent(this.floor);
}

class CTChangeTableOldEvent extends ChangeTableEvent {
  final table;

  CTChangeTableOldEvent(this.table);
}

class CTChangeTableNewEvent extends ChangeTableEvent {
  final table;

  CTChangeTableNewEvent(this.table);
}

class CTChangeVisibleConfirmPopupEvent extends ChangeTableEvent {
  final isVisible;

  CTChangeVisibleConfirmPopupEvent(this.isVisible);
}
