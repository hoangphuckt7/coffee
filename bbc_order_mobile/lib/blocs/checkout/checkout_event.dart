// ignore_for_file: prefer_typing_uninitialized_variables

part of 'checkout_bloc.dart';

@immutable
abstract class CheckoutEvent {}

class InitialEvent extends CheckoutEvent {}

class ErrorEvent extends CheckoutEvent {
  final errMsg;

  ErrorEvent(this.errMsg);
}

class ChangeQuantityEvent extends CheckoutEvent {}

class ChangeSugarEvent extends CheckoutEvent {}

class ChangeIceEvent extends CheckoutEvent {}

class ChangeNoteEvent extends CheckoutEvent {}
