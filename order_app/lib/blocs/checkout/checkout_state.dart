// ignore_for_file: prefer_typing_uninitialized_variables

part of 'checkout_bloc.dart';

@immutable
abstract class CheckoutState {}

class COInitialState extends CheckoutState {}

class COErrorState extends CheckoutState {
  final errMsg;

  COErrorState(this.errMsg);
}

class COUpdatedLoadingState extends CheckoutState {
  final isLoading;
  final labelLoading;

  COUpdatedLoadingState(this.isLoading, this.labelLoading);
}

class COChangedQuantityState extends CheckoutState {
  final detail;
  final listController;

  COChangedQuantityState(this.detail, this.listController);
}

class COChangedSugarState extends CheckoutState {
  final detail;

  COChangedSugarState(this.detail);
}

class COChangedIceState extends CheckoutState {
  final detail;

  COChangedIceState(this.detail);
}

class COChangedNoteState extends CheckoutState {
  final detail;

  COChangedNoteState(this.detail);
}

class COGoBackOrderState extends CheckoutState {}

class COGoToPickTableState extends CheckoutState {}
