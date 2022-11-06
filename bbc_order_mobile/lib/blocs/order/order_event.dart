// ignore_for_file: prefer_typing_uninitialized_variables

part of 'order_bloc.dart';

@immutable
abstract class OrderEvent {}

class InitialEvent extends OrderEvent {}

class LoadCateItemEvent extends OrderEvent {}

class ErrorEvent extends OrderEvent {
  final errMsg;

  ErrorEvent(this.errMsg);
}

class FilterEvent extends OrderEvent {
  final cate;
  final search;

  FilterEvent(this.cate, this.search);
}

class ChangeSugarEvent extends OrderEvent {
  final item;
  final step;

  ChangeSugarEvent(this.item, this.step);
}

class ChangeIceEvent extends OrderEvent {
  final item;
  final step;

  ChangeIceEvent(this.item, this.step);
}

class AddToCartEvent extends OrderEvent {
  final lstODetail;
  final item;

  AddToCartEvent(this.lstODetail, this.item);
}
