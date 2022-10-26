// ignore_for_file: prefer_typing_uninitialized_variables

part of 'home_bloc.dart';

@immutable
abstract class HomeEvent {}

class InitialEvent extends HomeEvent {}

class LoadDataEvent extends HomeEvent {}

class UpdateLoadingEvent extends HomeEvent {
  final isLoading;
  final labelLoading;

  UpdateLoadingEvent(this.isLoading, this.labelLoading);
}

class OrderChangeEvent extends HomeEvent {
  final orderId;
  final lstOrderDetails;

  OrderChangeEvent(this.orderId, this.lstOrderDetails);
}

class OrderDoneChangeEvent extends HomeEvent {
  final orderId;
  final lstOrderDetails;

  OrderDoneChangeEvent(this.orderId, this.lstOrderDetails);
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

class ItemCheckboxChangeEvent extends HomeEvent {
  final check;

  ItemCheckboxChangeEvent(this.check);
}

class OrderTabChangeEvent extends HomeEvent {
  final isNew;
  final lstCurrentOrder;
  final lstCurrentOrderDetail;

  OrderTabChangeEvent(
    this.isNew,
    this.lstCurrentOrder,
    this.lstCurrentOrderDetail,
  );
}

class OrderSubmitEvent extends HomeEvent {
  final isNew;
  final selectedOrder;
  final lstOrders;
  final selectedOrderDone;
  final lstOrdersDone;
  final lstDetails;
  final pinnedOrder;

  OrderSubmitEvent(
    this.isNew,
    this.selectedOrder,
    this.lstOrders,
    this.selectedOrderDone,
    this.lstOrdersDone,
    this.lstDetails,
    this.pinnedOrder,
  );
}

class RecieveNewOrderEvent extends HomeEvent {
  final lstOrder;

  RecieveNewOrderEvent(this.lstOrder);
}

class ListenRecieveNewOrderEvent extends HomeEvent {}
