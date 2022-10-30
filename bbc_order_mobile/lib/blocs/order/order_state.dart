// ignore_for_file: prefer_typing_uninitialized_variables

part of 'order_bloc.dart';

@immutable
abstract class OrderState {}

class InitialState extends OrderState {}

class LoadedCateItemState extends OrderState {
  final lstCate;
  final selectedCate;
  final lstItem;

  LoadedCateItemState(this.lstCate, this.selectedCate, this.lstItem);
}

class FilteredState extends OrderState {
  final cate;
  final search;
  final lstItem;

  FilteredState(this.cate, this.search, this.lstItem);
}
