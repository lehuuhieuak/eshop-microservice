﻿namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResult(bool IsSuccess);
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Product ID cannot be empty.");
        }
    }

    public class DeleteProductCommandHandler(IDocumentSession session)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
