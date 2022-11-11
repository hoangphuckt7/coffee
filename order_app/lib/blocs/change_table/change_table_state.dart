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
