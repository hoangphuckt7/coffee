// ignore_for_file: prefer_typing_uninitialized_variables

part of 'pick_table_bloc.dart';

@immutable
abstract class PickTableState {}

class PTInitialState extends PickTableState {}

class PTUpdatedLoadingState extends PickTableState {
  final isLoading;
  final labelLoading;

  PTUpdatedLoadingState(this.isLoading, this.labelLoading);
}

class PTErrorState extends PickTableState {
  final errMsg;

  PTErrorState(this.errMsg);
}

class PTChangedTableState extends PickTableState {
  final table;

  PTChangedTableState(this.table);
}

class PTChangedFloorState extends PickTableState {
  final floor;
  final listTable;
  final selectedTable;

  PTChangedFloorState(
    this.floor,
    this.listTable,
    this.selectedTable,
  );
}

class PTLoadedFloorTableState extends PickTableState {
  final selectedFloor;
  final listFloor;
  final selectedTable;
  final listTable;

  PTLoadedFloorTableState(
    this.selectedFloor,
    this.listFloor,
    this.selectedTable,
    this.listTable,
  );
}

class PTShowPopupConfirmExitState extends PickTableState {
  final isVisible;

  PTShowPopupConfirmExitState(this.isVisible);
}
