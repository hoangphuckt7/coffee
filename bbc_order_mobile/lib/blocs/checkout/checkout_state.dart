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
