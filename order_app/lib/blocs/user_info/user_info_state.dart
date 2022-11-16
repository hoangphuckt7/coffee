// ignore_for_file: prefer_typing_uninitialized_variables

part of 'user_info_bloc.dart';

@immutable
abstract class UserInfoState {}

class UIInitialState extends UserInfoState {}

class UIErrorState extends UserInfoState {
  final errMsg;

  UIErrorState(this.errMsg);
}

class UISuccessState extends UserInfoState {
  final sucMsg;

  UISuccessState(this.sucMsg);
}

class UIUpdatedLoadingState extends UserInfoState {
  final isLoading;
  final labelLoading;

  UIUpdatedLoadingState(this.isLoading, this.labelLoading);
}

class UIShowPopupConfirmPasswordState extends UserInfoState {
  final isVisible;

  UIShowPopupConfirmPasswordState(this.isVisible);
}

class UIInvalidFullNameState extends UserInfoState {
  final errMsg;

  UIInvalidFullNameState(this.errMsg);
}

class UIInvalidOldPassState extends UserInfoState {
  final errMsg;

  UIInvalidOldPassState(this.errMsg);
}

class UIInvalidNewPassState extends UserInfoState {
  final errMsg;

  UIInvalidNewPassState(this.errMsg);
}

class UIInvalidNewPassConfirmState extends UserInfoState {
  final errMsgNewPass;
  final errMsgNewPassConfirm;

  UIInvalidNewPassConfirmState(this.errMsgNewPass, this.errMsgNewPassConfirm);
}

class UILoadedInfoState extends UserInfoState {
  final fullname;

  UILoadedInfoState(this.fullname);
}
