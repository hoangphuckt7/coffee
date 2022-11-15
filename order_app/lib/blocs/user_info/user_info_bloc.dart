// ignore_for_file: depend_on_referenced_packages

import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:meta/meta.dart';
import 'package:orderr_app/models/user/user_model.dart';
import 'package:orderr_app/repositories/user_repo.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:tiengviet/tiengviet.dart';

part 'user_info_event.dart';
part 'user_info_state.dart';

class UserInfoBloc extends Bloc<UserInfoEvent, UserInfoState> {
  final _userRepo = UserRepo();
  UserInfoBloc() : super(UIInitialState()) {
    on<UIChangeFullNameEvent>(_onChangeFullName);
    on<UIChangeOldPassEvent>(_onChangeOldPass);
    on<UIChangeNewPassEvent>(_onChangeNewPass);
    on<UIChangeNewPassConfirmEvent>(_onChangeNewPassConfirm);
    // action
    on<UILoadInfoEvent>(_onLoadInfo);
    on<UIUpdateInfoEvent>(_onUpdateInfo);
    on<UIUpdatePasswordEvent>(_onUpdatePasswor);
  }

  void _onChangeFullName(
      UIChangeFullNameEvent event, Emitter<UserInfoState> emit) {
    try {
      String? fullName = event.fullName;
      String? erMsg;
      if (fullName == null || fullName == '') {
        erMsg = 'Họ và tên không được trống.';
      } else if (!Fn.validHumanName(TiengViet.parse(fullName))) {
        erMsg = 'Họ và tên không được chứa số hoặc ký tự đặc biệt.';
      }
      emit(UIInvalidFullNameState(erMsg));
    } catch (e) {
      emit(UIErrorState(AppInfo.ErrMsg));
      log('UserInfoBloc - _onChangeFullName - ${e.toString()}');
    }
  }

  void _onChangeOldPass(
      UIChangeOldPassEvent event, Emitter<UserInfoState> emit) {
    try {
      String? oldPass = event.oldPass;
      String? erMsg;
      if (oldPass == null || oldPass == '') {
        erMsg = 'Mật khẩu cũ không được trống.';
      }
      emit(UIInvalidOldPassState(erMsg));
    } catch (e) {
      emit(UIErrorState(AppInfo.ErrMsg));
      log('UserInfoBloc - _onChangeOldPass - ${e.toString()}');
    }
  }

  void _onChangeNewPass(
      UIChangeNewPassEvent event, Emitter<UserInfoState> emit) {
    try {
      String? newPass = event.newPass;
      String? erMsg;
      if (newPass == null || newPass == '') {
        erMsg = 'Mật khẩu mới không được trống.';
      }
      emit(UIInvalidNewPassState(erMsg));
    } catch (e) {
      emit(UIErrorState(AppInfo.ErrMsg));
      log('UserInfoBloc - _onChangeOldPass - ${e.toString()}');
    }
  }

  void _onChangeNewPassConfirm(
      UIChangeNewPassConfirmEvent event, Emitter<UserInfoState> emit) {
    try {
      String? newPass = event.newPass;
      String? errNewPass;
      if (newPass == null || newPass == '') {
        errNewPass = 'Mật khẩu mới không được trống.';
      }

      String? newPassConfirm = event.newPassConfirm;
      String? errNewPassConfirm;
      if (newPassConfirm == null || newPassConfirm == '') {
        errNewPassConfirm = 'Mật khẩu xác nhận không được trống.';
      } else if (newPass != newPassConfirm) {
        errNewPassConfirm = 'Mật khẩu xác nhận không giống mật khẩu mới.';
      } else {
        errNewPassConfirm = null;
      }

      emit(UIInvalidNewPassConfirmState(errNewPass, errNewPassConfirm));
    } catch (e) {
      emit(UIErrorState(AppInfo.ErrMsg));
      log('UserInfoBloc - _onChangeOldPass - ${e.toString()}');
    }
  }

  void _onLoadInfo(UILoadInfoEvent event, Emitter<UserInfoState> emit) async {}

  void _onUpdateInfo(
      UIUpdateInfoEvent event, Emitter<UserInfoState> emit) async {
    try {
      var resp =
          await _userRepo.updateInfo(UserModel(event.fullname, null, null));
      if (resp is bool && resp) {
        emit(UIUpdatedInfoState(event.fullname));
        return;
      }
      emit(UIErrorState(resp ?? 'Cập nhật thông tin thất bại'));
    } catch (e) {
      emit(UIErrorState(AppInfo.ErrMsg));
      log('UserInfoBloc - _onUpdateInfo - ${e.toString()}');
    }
  }

  void _onUpdatePasswor(
      UIUpdatePasswordEvent event, Emitter<UserInfoState> emit) async {
    try {
      var resp = await _userRepo.updateInfo(UserModel(
        null,
        event.oldPass,
        event.newPass,
      ));
      if (resp is bool && resp) {
        emit(UIUpdatedPasswordState());
        return;
      }
      emit(UIErrorState(resp ?? 'Cập nhật mật khẩu thất bại'));
    } catch (e) {
      emit(UIErrorState(AppInfo.ErrMsg));
      log('UserInfoBloc - _onUpdatePasswor - ${e.toString()}');
    }
  }
}