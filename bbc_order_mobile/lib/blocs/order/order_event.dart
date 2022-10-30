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
