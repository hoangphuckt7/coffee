// ignore_for_file: prefer_typing_uninitialized_variables

part of 'home_bloc.dart';

@immutable
abstract class HomeEvent {}

class HomeInitialEvent extends HomeEvent {}

class HomeLoadDataEvent extends HomeEvent {}

class HomeUpdateLoadingEvent extends HomeEvent {
  final isLoading;
  final labelLoading;

  HomeUpdateLoadingEvent(this.isLoading, this.labelLoading);
}

class HomeOrderChangeEvent extends HomeEvent {
  final orderId;
  final lstOrderDetails;

  HomeOrderChangeEvent(this.orderId, this.lstOrderDetails);
}

class HomeOrderDoneChangeEvent extends HomeEvent {
  final orderId;
  final lstOrderDetails;

  HomeOrderDoneChangeEvent(this.orderId, this.lstOrderDetails);
}

class HomeOrderPinEvent extends HomeEvent {
  final order;
  final lstOrders;

  HomeOrderPinEvent(this.order, this.lstOrders);
}

class HomeOrderScrollEvent extends HomeEvent {
  final showArrowTop;
  final showArrowBot;

  HomeOrderScrollEvent(this.showArrowTop, this.showArrowBot);
}

class HomeItemCheckboxChangeEvent extends HomeEvent {
  final check;

  HomeItemCheckboxChangeEvent(this.check);
}

class HomeOrderTabChangeEvent extends HomeEvent {
  final isNew;
  final lstCurrentOrder;
  final lstCurrentOrderDetail;

  HomeOrderTabChangeEvent(
    this.isNew,
    this.lstCurrentOrder,
    this.lstCurrentOrderDetail,
  );
}

class HomeOrderSubmitEvent extends HomeEvent {
  final isNew;
  final selectedOrder;
  final lstOrders;
  final selectedOrderDone;
  final lstOrdersDone;
  final lstDetails;
  final pinnedOrder;

  HomeOrderSubmitEvent(
    this.isNew,
    this.selectedOrder,
    this.lstOrders,
    this.selectedOrderDone,
    this.lstOrdersDone,
    this.lstDetails,
    this.pinnedOrder,
  );
}

class HomeRecieveNewOrderEvent extends HomeEvent {
  final lstOrder;

  HomeRecieveNewOrderEvent(this.lstOrder);
}

class HomeListenRecieveNewOrderEvent extends HomeEvent {}
