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

  CTLoadedFloorTableState(
    this.selectedFloorOld,
    this.selectedTableOld,
    this.selectedFloorNew,
    this.selectedTableNew,
    this.lstFloor,
    this.lstTableOld,
    this.lstTableNew,
  );
}

class CTChangedFloorOldState extends ChangeTableState {
  final floor;
  final listTable;
  final selectedTable;

  CTChangedFloorOldState(this.floor, this.listTable, this.selectedTable);
}

class CTChangedFloorNewState extends ChangeTableState {
  final floor;
  final listTable;
  final selectedTable;

  CTChangedFloorNewState(this.floor, this.listTable, this.selectedTable);
}

class CTChangedTableOldState extends ChangeTableState {
  final table;

  CTChangedTableOldState(this.table);
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
