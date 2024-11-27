using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class UserBusinessRules : BaseBusinessRules
{
    IUserDal _userDal;

    public UserBusinessRules(IUserDal userDal)
    {
        _userDal = userDal;
    }

    public async Task IsExistsUser(Guid userId)
    {
        var result = await _userDal.GetAsync(
            predicate:a => a.Id == userId, 
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }

    public async Task IsExistsUserByMail(string email)
    {
        var result = await _userDal.GetAsync(
            predicate: a => a.Email == email,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }

    public async Task IsExistsUserMail(string email)
    {
        var result = await _userDal.GetAsync(
            predicate: a => a.Email == email,
            enableTracking: false);

        if (result != null)
        {
            throw new BusinessException(BusinessMessages.DataAvailable);
        }
    }

    public async Task IsExistsResetToken(string resetToken)
    {
        var test = await _userDal.GetListAsync();

        var result = await _userDal.GetAsync(
            predicate: a => a.PasswordReset == resetToken,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}