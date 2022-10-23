// ignore_for_file: prefer_typing_uninitialized_variables

part of 'pick_table_bloc.dart';

@immutable
abstract class PickTableState {}

class PickTableInitial extends PickTableState {}

class InitialState extends PickTableState {}

class LogoutState extends PickTableState {}

class ErrorState extends PickTableState {
  final errMsg;

  ErrorState(this.errMsg);
}
