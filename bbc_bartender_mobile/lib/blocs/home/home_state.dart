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

class UpdateLoadingState extends HomeState {
  final isLoading;
  final labelLoading;

  UpdateLoadingState(this.isLoading, this.labelLoading);
}

// -------------------------------------------------- Items
class ItemsLoadedState extends HomeState {
  final isSuccess;
  final msg;

  ItemsLoadedState(this.isSuccess, this.msg);
}

// -------------------------------------------------- Orders
class OrdersLoadedState extends HomeState {
  final selectedOrder;
  final lstOrders;
  final selectedOrderDone;
  final lstOrdersDone;
  final lstOrderDetails;
  final fullName;

  OrdersLoadedState(
    this.selectedOrder,
    this.lstOrders,
    this.selectedOrderDone,
    this.lstOrdersDone,
    this.lstOrderDetails,
    this.fullName,
  );
}

class OrdersChangedState extends HomeState {
  final orderId;
  final lstOrderDetails;

  OrdersChangedState(this.orderId, this.lstOrderDetails);
}

class OrdersDoneChangedState extends HomeState {
  final orderId;
  final lstOrderDetails;

  OrdersDoneChangedState(this.orderId, this.lstOrderDetails);
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

class ItemCheckboxChangedState extends HomeState {
  final check;

  ItemCheckboxChangedState(this.check);
}

class OrderTabChangedState extends HomeState {
  final isNew;
  final lstCurrentOrder;
  final lstCurrentOrderDetail;

  OrderTabChangedState(
      this.isNew, this.lstCurrentOrder, this.lstCurrentOrderDetail);
}

class OrderSubmitSuccessState extends HomeState {
  final selectedOrder;
  final lstOrders;
  final selectedOrderDone;
  final lstOrdersDone;
  final lstDetails;
  final pinnedOrder;

  OrderSubmitSuccessState(
    this.selectedOrder,
    this.lstOrders,
    this.selectedOrderDone,
    this.lstOrdersDone,
    this.lstDetails,
    this.pinnedOrder,
  );
}

class OrderSubmitFailState extends HomeState {
  final errMsg;

  OrderSubmitFailState(this.errMsg);
}

class RecieveNewOrderState extends HomeState {
  final lstOrder;
  final lstDetail;

  RecieveNewOrderState(this.lstOrder, this.lstDetail);
}
