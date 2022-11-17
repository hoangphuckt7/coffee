// ignore_for_file: prefer_typing_uninitialized_variables

part of 'home_bloc.dart';

@immutable
abstract class HomeState {}

// -------------------------------------------------- Common
class HomeInitialState extends HomeState {}

class HomeUserInfoLoadedState extends HomeState {
  final fullName;

  HomeUserInfoLoadedState(this.fullName);
}

class HomeErrorState extends HomeState {
  final errMsg;

  HomeErrorState(this.errMsg);
}

class HomeUpdateLoadingState extends HomeState {
  final isLoading;
  final labelLoading;

  HomeUpdateLoadingState(this.isLoading, this.labelLoading);
}

// -------------------------------------------------- Items
class HomeItemsLoadedState extends HomeState {
  final isSuccess;
  final msg;

  HomeItemsLoadedState(this.isSuccess, this.msg);
}

// -------------------------------------------------- Orders
class HomeOrdersLoadedState extends HomeState {
  final selectedOrder;
  final lstOrders;
  final selectedOrderDone;
  final lstOrdersDone;
  final lstOrderDetails;
  // final fullName;

  HomeOrdersLoadedState(
    this.selectedOrder,
    this.lstOrders,
    this.selectedOrderDone,
    this.lstOrdersDone,
    this.lstOrderDetails,
    // this.fullName,
  );
}

class HomeOrdersChangedState extends HomeState {
  final orderId;
  final lstOrderDetails;

  HomeOrdersChangedState(this.orderId, this.lstOrderDetails);
}

class HomeOrdersDoneChangedState extends HomeState {
  final orderId;
  final lstOrderDetails;

  HomeOrdersDoneChangedState(this.orderId, this.lstOrderDetails);
}

class HomeOrdersPinnedState extends HomeState {
  final order;
  final lstOrders;

  HomeOrdersPinnedState(this.order, this.lstOrders);
}

class HomeOrderScrolledState extends HomeState {
  final showArrowTop;
  final showArrowBot;

  HomeOrderScrolledState(this.showArrowTop, this.showArrowBot);
}

class HomeItemCheckboxChangedState extends HomeState {
  final check;

  HomeItemCheckboxChangedState(this.check);
}

class HomeOrderTabChangedState extends HomeState {
  final isNew;
  final lstCurrentOrder;
  final lstCurrentOrderDetail;

  HomeOrderTabChangedState(
      this.isNew, this.lstCurrentOrder, this.lstCurrentOrderDetail);
}

class HomeOrderSubmitSuccessState extends HomeState {
  final selectedOrder;
  final lstOrders;
  final selectedOrderDone;
  final lstOrdersDone;
  final lstDetails;
  final pinnedOrder;

  HomeOrderSubmitSuccessState(
    this.selectedOrder,
    this.lstOrders,
    this.selectedOrderDone,
    this.lstOrdersDone,
    this.lstDetails,
    this.pinnedOrder,
  );
}

class HomeOrderSubmitFailState extends HomeState {
  final errMsg;

  HomeOrderSubmitFailState(this.errMsg);
}

class HomeRecieveNewOrderState extends HomeState {
  final lstOrder;
  final lstDetail;

  HomeRecieveNewOrderState(this.lstOrder, this.lstDetail);
}
