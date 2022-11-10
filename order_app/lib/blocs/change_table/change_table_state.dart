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
