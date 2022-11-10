// ignore_for_file: prefer_typing_uninitialized_variables

part of 'pick_table_bloc.dart';

@immutable
abstract class PickTableState {}

class InitialState extends PickTableState {}

class UpdatedLoadingState extends PickTableState {
  final isLoading;
  final labelLoading;

  UpdatedLoadingState(this.isLoading, this.labelLoading);
}

class ErrorState extends PickTableState {
  final errMsg;

  ErrorState(this.errMsg);
}

class ChangedTableState extends PickTableState {
  final table;

  ChangedTableState(this.table);
}

class ChangedFloorState extends PickTableState {
  final floor;
  final listTable;
  final selectedTable;

  ChangedFloorState(
    this.floor,
    this.listTable,
    this.selectedTable,
  );
}

class LoadedFloorTableState extends PickTableState {
  final selectedFloor;
  final listFloor;
  final selectedTable;
  final listTable;

  LoadedFloorTableState(
    this.selectedFloor,
    this.listFloor,
    this.selectedTable,
    this.listTable,
  );
}
