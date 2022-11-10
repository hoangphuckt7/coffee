// ignore_for_file: prefer_typing_uninitialized_variables

part of 'order_bloc.dart';

@immutable
abstract class OrderEvent {}

class ORInitialEvent extends OrderEvent {}

class ORLoadCateItemEvent extends OrderEvent {}

class ORErrorEvent extends OrderEvent {
  final errMsg;

  ORErrorEvent(this.errMsg);
}

class ORFilterEvent extends OrderEvent {
  final cate;
  final search;

  ORFilterEvent(this.cate, this.search);
}

class ORChangeSugarEvent extends OrderEvent {
  final item;
  final step;

  ORChangeSugarEvent(this.item, this.step);
}

class ORChangeIceEvent extends OrderEvent {
  final item;
  final step;

  ORChangeIceEvent(this.item, this.step);
}

class ORAddToCartEvent extends OrderEvent {
  final lstODetail;
  final item;

  ORAddToCartEvent(this.lstODetail, this.item);
}
