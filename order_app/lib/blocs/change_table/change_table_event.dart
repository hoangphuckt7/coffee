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

class CTShowPopupConfirmChangeEvent extends ChangeTableEvent {
  final isVisible;

  CTShowPopupConfirmChangeEvent(this.isVisible);
}

class CTConfirmChangeEvent extends ChangeTableEvent {
  final tableIdNew;
  final lstSelectedOrder;

  CTConfirmChangeEvent(this.tableIdNew, this.lstSelectedOrder);
}

class CTUpdateSelectedOrdersEvent extends ChangeTableEvent {
  final orderId;
  final listSelectedOrder;

  CTUpdateSelectedOrdersEvent(this.orderId, this.listSelectedOrder);
}

class CTUpdateCbxAllEvent extends ChangeTableEvent {
  final lstOrder;
  final selLen;

  CTUpdateCbxAllEvent(this.lstOrder, this.selLen);
}

class CTShowPopupSelectTableNewEvent extends ChangeTableEvent {
  final isVisible;

  CTShowPopupSelectTableNewEvent(this.isVisible);
}
