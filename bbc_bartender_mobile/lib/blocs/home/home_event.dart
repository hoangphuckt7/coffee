// ignore_for_file: prefer_typing_uninitialized_variables

part of 'home_bloc.dart';

@immutable
abstract class HomeEvent {}

class InitialEvent extends HomeEvent {}

class LoadDataEvent extends HomeEvent {}

class LogoutEvent extends HomeEvent {}

class OrderChangeEvent extends HomeEvent {
  final orderId;
  final lstOrderDetails;

  OrderChangeEvent(this.orderId, this.lstOrderDetails);
}

class OrderPinEvent extends HomeEvent {
  final order;
  final lstOrders;

  OrderPinEvent(this.order, this.lstOrders);
}

class OrderScrollEvent extends HomeEvent {
  final showArrowTop;
  final showArrowBot;

  OrderScrollEvent(this.showArrowTop, this.showArrowBot);
}
