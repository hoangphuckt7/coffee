// ignore_for_file: prefer_typing_uninitialized_variables

part of 'checkout_bloc.dart';

@immutable
abstract class CheckoutState {}

class InitialState extends CheckoutState {}

class ErrorState extends CheckoutState {
  final errMsg;

  ErrorState(this.errMsg);
}

class UpdatedLoadingState extends CheckoutState {
  final isLoading;
  final labelLoading;

  UpdatedLoadingState(this.isLoading, this.labelLoading);
}

class ChangedQuantityState extends CheckoutState {
  final detail;
  final listController;

  ChangedQuantityState(this.detail, this.listController);
}

class ChangedSugarState extends CheckoutState {
  final detail;

  ChangedSugarState(this.detail);
}

class ChangedIceState extends CheckoutState {
  final detail;

  ChangedIceState(this.detail);
}

class ChangedNoteState extends CheckoutState {
  final detail;

  ChangedNoteState(this.detail);
}

class GoBackOrderState extends CheckoutState {}

class GoToPickTableState extends CheckoutState {}
