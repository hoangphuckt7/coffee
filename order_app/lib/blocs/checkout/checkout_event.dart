// ignore_for_file: prefer_typing_uninitialized_variables

part of 'checkout_bloc.dart';

@immutable
abstract class CheckoutEvent {}

class COInitialEvent extends CheckoutEvent {}

class COErrorEvent extends CheckoutEvent {
  final errMsg;

  COErrorEvent(this.errMsg);
}

class COChangeQuantityEvent extends CheckoutEvent {
  final detail;
  final step;
  final listController;

  COChangeQuantityEvent(this.detail, this.step, this.listController);
}

class COChangeSugarEvent extends CheckoutEvent {
  final detail;
  final step;
  final indexDct;

  COChangeSugarEvent(this.detail, this.step, this.indexDct);
}

class COChangeIceEvent extends CheckoutEvent {
  final detail;
  final step;
  final indexDct;

  COChangeIceEvent(this.detail, this.step, this.indexDct);
}

class COChangeNoteEvent extends CheckoutEvent {
  final detail;
  final note;
  final indexDct;

  COChangeNoteEvent(this.detail, this.note, this.indexDct);
}

class COGoBackOrderEvent extends CheckoutEvent {}

class COConfirmOrderEvent extends CheckoutEvent {
  final order;

  COConfirmOrderEvent(this.order);
}

class COShowPopupConfirmCheckoutEvent extends CheckoutEvent {
  final isVisible;

  COShowPopupConfirmCheckoutEvent(this.isVisible);
}
