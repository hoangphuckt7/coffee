// ignore_for_file: prefer_typing_uninitialized_variables

part of 'order_bloc.dart';

@immutable
abstract class OrderState {}

class ORInitialState extends OrderState {}

class ORErrorState extends OrderState {
  final errMsg;

  ORErrorState(this.errMsg);
}

class ORUpdatedLoadingState extends OrderState {
  final isLoading;
  final labelLoading;

  ORUpdatedLoadingState(this.isLoading, this.labelLoading);
}

class ORLoadedCateItemState extends OrderState {
  final lstCate;
  final selectedCate;
  final lstItem;

  ORLoadedCateItemState(this.lstCate, this.selectedCate, this.lstItem);
}

class ORFilteredState extends OrderState {
  final cate;
  final search;
  final lstItem;

  ORFilteredState(this.cate, this.search, this.lstItem);
}

class ORChangedSugarState extends OrderState {
  final item;

  ORChangedSugarState(this.item);
}

class ORChangedIceState extends OrderState {
  final item;

  ORChangedIceState(this.item);
}

class ORAddedToCartState extends OrderState {
  final lstODetail;
  final item;

  ORAddedToCartState(this.lstODetail, this.item);
}
