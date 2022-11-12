// ignore_for_file: prefer_typing_uninitialized_variables

part of 'order_bloc.dart';

@immutable
abstract class OrderState {}

class InitialState extends OrderState {}

class ErrorState extends OrderState {
  final errMsg;

  ErrorState(this.errMsg);
}

class UpdatedLoadingState extends OrderState {
  final isLoading;
  final labelLoading;

  UpdatedLoadingState(this.isLoading, this.labelLoading);
}

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

class ChangedSugarState extends OrderState {
  final item;

  ChangedSugarState(this.item);
}

class ChangedIceState extends OrderState {
  final item;

  ChangedIceState(this.item);
}

class AddedToCartState extends OrderState {
  final lstODetail;
  final item;

  AddedToCartState(this.lstODetail, this.item);
}

class ORChangedVisibleConfirmPopupState extends OrderState {
  final isVisible;

  ORChangedVisibleConfirmPopupState(this.isVisible);
}