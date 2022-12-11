// ignore_for_file: prefer_typing_uninitialized_variables

part of 'change_table_bloc.dart';

@immutable
abstract class ChangeTableState {}

class CTInitialState extends ChangeTableState {}

class CTErrorState extends ChangeTableState {
  final errMsg;

  CTErrorState(this.errMsg);
}

class CTUpdatedLoadingState extends ChangeTableState {
  final isLoading;
  final labelLoading;

  CTUpdatedLoadingState(this.isLoading, this.labelLoading);
}

class CTLoadedFloorTableState extends ChangeTableState {
  final selectedFloorOld;
  final selectedTableOld;
  final selectedFloorNew;
  final selectedTableNew;
  final lstFloor;
  final lstTableOld;
  final lstTableNew;
  final lstOrders;

  CTLoadedFloorTableState(
    this.selectedFloorOld,
    this.selectedTableOld,
    this.selectedFloorNew,
    this.selectedTableNew,
    this.lstFloor,
    this.lstTableOld,
    this.lstTableNew,
    this.lstOrders,
  );
}

class CTChangedFloorOldState extends ChangeTableState {
  final floor;
  final listTable;
  final selectedTable;
  final listOrder;

  CTChangedFloorOldState(
    this.floor,
    this.listTable,
    this.selectedTable,
    this.listOrder,
  );
}

class CTChangedFloorNewState extends ChangeTableState {
  final floor;
  final listTable;
  final selectedTable;

  CTChangedFloorNewState(
    this.floor,
    this.listTable,
    this.selectedTable,
  );
}

class CTChangedTableOldState extends ChangeTableState {
  final table;
  final lstOrder;

  CTChangedTableOldState(this.table, this.lstOrder);
}

class CTChangedTableNewState extends ChangeTableState {
  final table;

  CTChangedTableNewState(this.table);
}

class CTShowPopupConfirmChangeState extends ChangeTableState {
  final isVisible;

  CTShowPopupConfirmChangeState(this.isVisible);
}

class CTGoToPickTableState extends ChangeTableState {}

class CTUpdateSelectedOrdersState extends ChangeTableState {
  final listSelectedOrders;

  CTUpdateSelectedOrdersState(this.listSelectedOrders);
}

class CTUpdateCbxAllState extends ChangeTableState {
  final listSelectedOrder;

  CTUpdateCbxAllState(this.listSelectedOrder);
}

class CTShowPopupSelectTableNewState extends ChangeTableState {
  final isVisible;

  CTShowPopupSelectTableNewState(this.isVisible);
}
