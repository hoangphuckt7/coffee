// ignore_for_file: prefer_typing_uninitialized_variables

part of 'user_info_bloc.dart';

@immutable
abstract class UserInfoEvent {}

class UIInitialEvent extends UserInfoEvent {}

class UIErrorEvent extends UserInfoEvent {
  final errMsg;

  UIErrorEvent(this.errMsg);
}

class UISuccessEvent extends UserInfoEvent {
  final sucMsg;

  UISuccessEvent(this.sucMsg);
}

class UIShowPopupConfirmPasswordEvent extends UserInfoEvent {
  final isVisible;

  UIShowPopupConfirmPasswordEvent(this.isVisible);
}

// valid data
class UIChangeFullNameEvent extends UserInfoEvent {
  final fullName;

  UIChangeFullNameEvent(this.fullName);
}

class UIChangeOldPassEvent extends UserInfoEvent {
  final oldPass;

  UIChangeOldPassEvent(this.oldPass);
}

class UIChangeNewPassEvent extends UserInfoEvent {
  final newPass;

  UIChangeNewPassEvent(this.newPass);
}

class UIChangeNewPassConfirmEvent extends UserInfoEvent {
  final newPass;
  final newPassConfirm;

  UIChangeNewPassConfirmEvent(this.newPass, this.newPassConfirm);
}

// action
class UILoadInfoEvent extends UserInfoEvent {}

class UIUpdateInfoEvent extends UserInfoEvent {
  final fullname;

  UIUpdateInfoEvent(this.fullname);
}

class UIUpdatePasswordEvent extends UserInfoEvent {
  final oldPass;
  final newPass;

  UIUpdatePasswordEvent(this.oldPass, this.newPass);
}
