// ignore_for_file: prefer_typing_uninitialized_variables

part of 'checkout_bloc.dart';

@immutable
abstract class CheckoutEvent {}

class InitialEvent extends CheckoutEvent {}

class ErrorEvent extends CheckoutEvent {
  final errMsg;

  ErrorEvent(this.errMsg);
}

class ChangeQuantityEvent extends CheckoutEvent {
  final detail;
  final step;

  ChangeQuantityEvent(this.detail, this.step);
}

class ChangeSugarEvent extends CheckoutEvent {
  final detail;
  final step;
  final indexDct;

  ChangeSugarEvent(this.detail, this.step, this.indexDct);
}

class ChangeIceEvent extends CheckoutEvent {
  final detail;
  final step;
  final indexDct;

  ChangeIceEvent(this.detail, this.step, this.indexDct);
}

class ChangeNoteEvent extends CheckoutEvent {
  final detail;
  final note;
  final indexDct;

  ChangeNoteEvent(this.detail, this.note, this.indexDct);
}

class GoBackOrderEvent extends CheckoutEvent {}

class ConfirmOrderEvent extends CheckoutEvent {
  final order;

  ConfirmOrderEvent(this.order);
}

class GoToPickTableEvent extends CheckoutEvent {}
