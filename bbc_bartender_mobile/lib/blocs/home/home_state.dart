// ignore_for_file: prefer_typing_uninitialized_variables

part of 'home_bloc.dart';

@immutable
abstract class HomeState {}

// -------------------------------------------------- Common
class InitialState extends HomeState {}

class LogoutState extends HomeState {}

class UserInfoLoadedState extends HomeState {
  final fullName;

  UserInfoLoadedState(this.fullName);
}

class ErrorState extends HomeState {
  final errMsg;

  ErrorState(this.errMsg);
}

// -------------------------------------------------- Items
class ItemsLoadingState extends HomeState {
  final loadingMsg;

  ItemsLoadingState(this.loadingMsg);
}

class ItemsLoadedState extends HomeState {
  final isSuccess;
  final msg;

  ItemsLoadedState(this.isSuccess, this.msg);
}

// -------------------------------------------------- Orders
class OrdersLoadingState extends HomeState {
  final loadingMsg;

  OrdersLoadingState(this.loadingMsg);
}

class OrdersLoadedState extends HomeState {
  final lstOrders;
  final lstOrderDetails;

  OrdersLoadedState(this.lstOrders, this.lstOrderDetails);
}

class OrdersChangedState extends HomeState {
  final orderId;
  final lstOrderDetails;

  OrdersChangedState(this.orderId, this.lstOrderDetails);
}

class OrdersPinnedState extends HomeState {
  final order;
  final lstOrders;

  OrdersPinnedState(this.order, this.lstOrders);
}

class OrderScrolledState extends HomeState {
  final showArrowTop;
  final showArrowBot;

  OrderScrolledState(this.showArrowTop, this.showArrowBot);
}
